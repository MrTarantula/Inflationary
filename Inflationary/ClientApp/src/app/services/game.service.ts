import { Inject, Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr";
import { Message } from '../models/Message';
import { Player } from '../models/Player';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private player: Player | undefined;
  public messages: Message[] = [];

  public connection: signalR.HubConnection;

  constructor(@Inject('BASE_URL') private baseUrl: string) {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:7011/game')
      .build();

    this.connection
      .start()
      .then(() => console.log('Connected!'))
      .catch(err => console.log('Error connecting: ' + err));

    this.connection.on('messages', (data) => {
      this.messages = data;
    })
  }

  public join(name: string): void {
    this.connection.invoke('join', name).then(data => {
      this.player = data;
    })
      .catch(err => console.error(err));
  }

  public leave(name: string): void {
    this.connection.invoke('leave', name)
      .catch(err => console.error(err));
  }

  public inflate(sentence: string): void {
    this.connection.invoke('inflate', this.player?.name, sentence)
      .catch(err => console.error(err));
  }

  public async check(sentence: string): Promise<string> {
    try {
      return this.connection.invoke('check', sentence);
    } catch (err) {
      return "A connection error has occurred";
    }
  }
}


