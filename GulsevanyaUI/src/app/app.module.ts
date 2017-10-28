import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { LobbyListComponent } from './lobby-list/lobby-list.component';
import { LobbyCreateComponent } from './lobby-create/lobby-create.component';
import { AlertModule } from 'ngx-bootstrap';
import { LobbyViewComponent } from './lobby-view/lobby-view.component';
import { LobbyViewService } from "./lobby-view/lobby-view.service";
import { LobbyItemComponent } from './lobby-item/lobby-item.component';

//Auth 0
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ROUTES } from './app.routes';
import { AuthService } from './auth/auth.service';
import { CallbackComponent } from './callback/callback.component';


@NgModule({
  declarations: [
    AppComponent,
    LobbyListComponent,
    LobbyCreateComponent,
    LobbyViewComponent,
    LobbyItemComponent,
    CallbackComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    AlertModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(ROUTES)
  ],
  providers: [
    LobbyViewService,
    AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
