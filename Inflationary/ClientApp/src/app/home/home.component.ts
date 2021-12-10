import { Component } from '@angular/core';
import { GameService } from '../services/game.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public sentence: string = "";
  constructor(private gameService: GameService) {
  }

  addMessage() {
    this.gameService.inflate(this.sentence);
    this.sentence = "";
  }
}
