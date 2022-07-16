import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { BehaviorSubject } from 'rxjs';
import { environment } from '../../../environments/environment';
import { SettingService } from './setting.service';

@Injectable({
  providedIn: 'root'
})
export class RealTimeService {
  connection: signalR.HubConnection;
  broadcastMessage: BehaviorSubject<any>;

  constructor(
    private settingService: SettingService
  ) {
    this.broadcastMessage = new BehaviorSubject<any>(null);
  }

  // Establish a connection to the SignalR server hub
  public initiateSignalrConnection(): Promise<void> {
    return new Promise((resolve, reject) => {
      this.connection = new signalR.HubConnectionBuilder()
        .withUrl(this.settingService.data.realTimeApi) // the SignalR server url as set in the .NET Project properties and Startup class
        .build();

      this.setSignalrClientMethods();

      this.connection
        .start()
        .then(() => {
          console.log(
            `SignalR connection success! connectionId: ${this.connection.connectionId} `
          );
          resolve();
        })
        .catch((error) => {
          console.log(`SignalR connection error: ${error}`);
          reject();
        });
    });
    // return new Promise((resolve) => {
    //   resolve();
    // });
  }

  // This method will implement the methods defined in the ISignalrDemoHub interface in the SignalrDemo.Server .NET solution
  private setSignalrClientMethods(): void {
    this.connection.on('BroadcastMessage', (message: any) => {
      this.broadcastMessage.next(message);
    });
  }
}
