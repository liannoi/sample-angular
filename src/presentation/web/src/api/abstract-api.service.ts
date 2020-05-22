import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {catchError, delay} from 'rxjs/operators';

@Injectable()
export abstract class AbstractApiService<TModel, TListModel> {
  protected endpoint: string;

  protected constructor(protected http: HttpClient) {
  }

  public getAll(timeout?: number): Observable<TListModel> {
    return this.http.get<TListModel>(this.endpoint)
      .pipe(catchError(this.handleError))
      .pipe(delay(timeout > 0 ? timeout : 0));
  }

  public create(model: TModel): Observable<TModel> {
    return this.http.post<TModel>(this.endpoint, model)
      .pipe(catchError(this.handleError));
  }

  public getById(id: number): Observable<TModel> {
    return this.http.get<TModel>(`${this.endpoint}/${id}`)
      .pipe(catchError(this.handleError));
  }

  public update(id: number, model: TModel): Observable<TModel> {
    return this.http.put<TModel>(`${this.endpoint}/${id}`, model)
      .pipe(catchError(this.handleError));
  }

  public delete(id: number): Observable<TModel> {
    return this.http.delete<TModel>(`${this.endpoint}/${id}`)
      .pipe(catchError(this.handleError));
  }

  protected handleError(error) {
    let errorMessage: string = error.error instanceof ErrorEvent ? `Error: ${error.error.message}` : `Error Code: ${error.status}\nMessage: ${error.message}`;
    console.log(errorMessage);

    return throwError(errorMessage);
  }
}