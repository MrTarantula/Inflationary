import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

import { GameService } from '../services/game.service';


@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm = this.formBuilder.group({
    name: ''
  });

  constructor(private formBuilder: FormBuilder,
    private gameService: GameService,
    private router: Router) {
  }

  onSubmit(name: string) {
    this.gameService.join(name);
      this.router.navigate(['/game']);
  }
}
