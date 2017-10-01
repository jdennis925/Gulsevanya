import { Component, OnInit } from '@angular/core';
import { LobbyItem } from './LobbyItem';

@Component({
  selector: 'app-lobby-list',
  templateUrl: './lobby-list.component.html',
  styleUrls: ['./lobby-list.component.css']
})
export class LobbyListComponent implements OnInit {
  public LobbyItems: LobbyItem[];
  
  constructor() {
    this.LobbyItems = new Array<LobbyItem>();
    this.LobbyItems.push(new LobbyItem("Laura's Lobby", "Laura"));
   }

  ngOnInit() {
  }

}
