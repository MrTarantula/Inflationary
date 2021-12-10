import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { GameService } from './services/game.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'Inflationary Game';

  constructor(private toastr: ToastrService, private gameService: GameService) {
    gameService.connection.on('alert', (data) => {
      this.toastr.success(data);
    });
  }
}
