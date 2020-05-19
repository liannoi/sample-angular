import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';

@Injectable()
export abstract class AbstractApiService<TModel, TListModel> {
  protected constructor(protected http: HttpClient) {
  }

  public abstract getAll(timeout?: number): Observable<TListModel>;

  public abstract getById(id: number): Observable<TModel>;

  public abstract create(model: TModel): Observable<TModel>;

  public abstract delete(model: TModel): Observable<TModel>;

  public abstract update(model: TModel): Observable<TModel>;

  protected handleError(error) {
    let errorMessage: string = '';

    if (error.error instanceof ErrorEvent) {
      // client-side error
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }

    console.log(errorMessage);

    return throwError(errorMessage);
  }
}
