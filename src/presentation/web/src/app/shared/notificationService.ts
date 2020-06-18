import {Injectable} from '@angular/core';
import {HubConnection, HubConnectionBuilder} from '@aspnet/signalr';
import {notificationsEndpoint, sendNotificationMethod} from './addresses.consts';
import {Notifiable} from '../common/services/notifiable';

@Injectable()
export class NotificationService implements Notifiable {
  private readonly _connection: HubConnection;

  constructor() {
    this._connection = new HubConnectionBuilder().withUrl(notificationsEndpoint).build();
  }

  public get connection(): HubConnection {
    return this._connection;
  }

  public send(message: string): void {
    this.connection.invoke(sendNotificationMethod, message);
  }

  public async run(): Promise<void> {
    return await this._connection.start()
      .then(() => console.log('Hub connection started'))
      .catch(err => console.log('Error while establishing connection'));
  }
}
