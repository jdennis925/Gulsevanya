import { EventEmitter, Injectable } from '@angular/core';
import { HubConnection } from '@aspnet/signalr-client';
import { LobbyMessage } from './LobbyMessage';

@Injectable()
export class LobbyViewService 
{
    foodchanged = new EventEmitter();
    messageReceived = new EventEmitter<LobbyMessage>();
    newCpuValue = new EventEmitter<Number>();
    connectionEstablished = new EventEmitter<Boolean>();
    connectionExists = false;

    private _hubConnection: HubConnection;

    constructor() {

        this._hubConnection = new HubConnection('http://localhost:60292/' + 'LobbyHub');

        this.registerOnServerEvents();

        this.startConnection();
    }

    private startConnection(): void {

        this._hubConnection.start()
            .then(() => {
                console.log('Lobby connection started');
                this.connectionEstablished.emit(true);
            })
            .catch(err => {
                console.log('Error while establishing connection' + err)
            });
    }

    
    private registerOnServerEvents(): void {
        this._hubConnection.on('UserJoined', (data: any) => {
            this.messageReceived.emit(data);
        });

        // this._hubConnection.on('FoodDeleted', (data: any) => {
        //     this.foodchanged.emit('this could be data');
        // });

        this._hubConnection.on('Send', (data: any) => {
            const recieved = `Recieved: ${data}`;
            console.log(recieved);
            this.messageReceived.emit(data);
        });
    }

}