import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable()
export abstract class AbstractApiService<TModel, TListModel> {
  protected constructor(protected http: HttpClient) {
  }

  public abstract getAll(limit: number, timeout?: number): Observable<TListModel>;

  public abstract getById(id: number): Observable<TModel>;

  public abstract create(model: TModel): Observable<TModel>;

  public abstract delete(model: TModel): Observable<TModel>;

  public abstract update(model: TModel): Observable<TModel>;
}
