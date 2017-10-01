import { Component, OnInit, NgZone } from '@angular/core';

//import { SignalRService } from '../../services/signalRService';
import { LobbyViewService } from './lobby-view.service';
import { LobbyMessage } from './LobbyMessage';


@Component({
  selector: 'app-lobby-view',
  templateUrl: './lobby-view.component.html',
  styleUrls: ['./lobby-view.component.css']
})
export class LobbyViewComponent implements OnInit {
  public allMessages: LobbyMessage[];
  
  constructor(private lobbyViewService : LobbyViewService, private ngZone: NgZone) 
  {
    this.subscribeToEvents();
    this.allMessages = new Array<LobbyMessage>();
  }

  ngOnInit() {
  }

  private subscribeToEvents(): void {
    this.lobbyViewService.connectionEstablished.subscribe(() => {
    });

    this.lobbyViewService.messageReceived.subscribe((message: LobbyMessage) => {
        this.ngZone.run(() => {
            console.log('trying to push message! ' + message);
            this.allMessages.push(new LobbyMessage(message.Message, message.Sent.toString()));
        });
    });
}
}
