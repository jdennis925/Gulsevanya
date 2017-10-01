import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { LobbyListComponent } from './lobby-list/lobby-list.component';
import { LobbyCreateComponent } from './lobby-create/lobby-create.component';
import { AlertModule } from 'ngx-bootstrap';
import { LobbyViewComponent } from './lobby-view/lobby-view.component';
import { LobbyViewService } from "./lobby-view/lobby-view.service";
import { LobbyItemComponent } from './lobby-item/lobby-item.component';

@NgModule({
  declarations: [
    AppComponent,
    LobbyListComponent,
    LobbyCreateComponent,
    LobbyViewComponent,
    LobbyItemComponent,
  ],
  imports: [
    BrowserModule,
    AlertModule
  ],
  providers: [
    LobbyViewService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
