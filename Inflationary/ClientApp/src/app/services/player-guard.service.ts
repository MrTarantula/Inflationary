import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot } from '@angular/router';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { PlayerManager } from './player-manager.service';

@Injectable({
    providedIn: 'root'
})
export class PlayerGuard implements CanActivate {
    canActivate(next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
            console.log(this.playerManager.player)
        if (this.playerManager.player == undefined) {
            console.log(this.playerManager.player)
            this.router.navigate(['/']);
        }
        return true;

    }

    constructor(private router: Router, private playerManager: PlayerManager) { }
}