import { Component, OnInit } from '@angular/core';
import { Player } from '../models/Player';
import { GameService } from '../services/game.service';

@Component({
  selector: 'player-list',
  templateUrl: './player-list.component.html',
  styleUrls: ['./player-list.component.css']
})
export class PlayerListComponent implements OnInit {
  public players: Player[] = [];

  constructor(private gameService: GameService) { }

  ngOnInit(): void {
    this.gameService.connection.on('players', (data) => {
      this.players = data;
    })
  }
}
