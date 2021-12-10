import { Component, OnInit } from '@angular/core';
import { Message } from '../models/Message';
import { GameService } from '../services/game.service';

@Component({
  selector: 'chat-window',
  templateUrl: './chat-window.component.html',
  styleUrls: ['./chat-window.component.css']
})
export class ChatWindowComponent implements OnInit {
  public messages: Message[] = [];

  constructor(private gameService: GameService) { }

  ngOnInit() {
    this.gameService.connection.on('messages', (data) => {
      this.messages = data;
    });

    this.gameService.connection.on('message', (data) => {
      this.messages.push(data);
    });
  }

  cheat(id: number) {
    let index = this.messages.findIndex(m => m.id == id);
    this.messages[index].cheat = !this.messages[index].cheat;
  }
}
