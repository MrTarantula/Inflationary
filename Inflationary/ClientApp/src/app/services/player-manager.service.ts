import { Inject, Injectable } from '@angular/core';
import { Player } from '../models/Player';

@Injectable({
    providedIn: 'root'
})
export class PlayerManager {
    public player: Player | undefined;

    constructor() { }

    setPlayer(newPlayer: Player) {
        this.player = newPlayer;
    }
}


