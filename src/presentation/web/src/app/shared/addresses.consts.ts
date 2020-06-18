export const serverAddress: string = 'https://localhost:5001';
export const baseApiAddress = `${serverAddress}/api`;

export const manufacturersEndpoint = `${baseApiAddress}/manufacturers`;
export const productsEndpoint = `${baseApiAddress}/products`;
export const productPhotosEndpoint = `${baseApiAddress}/productPhotos`;

export const notificationsEndpoint = `${serverAddress}/notifications`;
export const receiveNotificationMethod = 'ReceiveNotification';
export const sendNotificationMethod = 'SendNotification';
