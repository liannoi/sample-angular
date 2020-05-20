import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';

@Injectable()
export abstract class AbstractApiService<TModel, TListModel> {
  protected constructor(protected http: HttpClient) {
  }

  public abstract getAll(timeout?: number): Observable<TListModel>;

  public abstract create(model: TModel): Observable<TModel>;

  public abstract getById(id: number): Observable<TModel>;

  public abstract update(id: number, model: TModel): Observable<TModel>;

  public abstract delete(id: number): Observable<TModel>;

  protected handleError(error) {
    let errorMessage: string = error.error instanceof ErrorEvent ? `Error: ${error.error.message}` : `Error Code: ${error.status}\nMessage: ${error.message}`;
    console.log(errorMessage);

    return throwError(errorMessage);
  }
}
