import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { GameService } from '../services/game.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public sentence: string = "";
  constructor(private gameService: GameService, private toastr: ToastrService) {
  }

  addMessage() {
    this.gameService.inflate(this.sentence);
    this.sentence = "";
  }

  check() {
    this.gameService.check(this.sentence).then(data => {
      this.toastr.error(data, "Check");
    });
  }
}
