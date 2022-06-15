import { Component, OnInit } from '@angular/core';
import { StoreService } from './store.service';

@Component({
    selector: 'app-game',
    templateUrl: './game.component.html',
    styles         : [

    ],
})

export class GameComponent implements OnInit {
    games: any;
    isLoading: boolean = false;
    displayedColumns: string[] = ['category','name', 'description', 'developer', 'publisher','price'];

    constructor(private storeService: StoreService) {}

    ngOnInit(): void {

        this.storeService.getStores().subscribe(
            (resp) => {
                this.games =resp.data;
                console.log(resp);
            },
            (response) => {
                console.log(response);
            }
        );
    }
}
