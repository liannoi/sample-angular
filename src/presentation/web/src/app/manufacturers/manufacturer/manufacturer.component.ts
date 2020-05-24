import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';

import {ManufacturersService} from '../shared/manufacturers.service';
import {ManufacturerModel} from '../shared/manufacturer.model';

@Component({
  selector: 'app-manufacturer',
  templateUrl: './manufacturer.component.html',
  providers: [ManufacturersService],
})
export class ManufacturerComponent implements OnInit, OnDestroy {
  public form: FormGroup;
  public model: ManufacturerModel;
  public isInitialized = false;
  private stop$ = new Subject<void>();

  constructor(private manufacturersService: ManufacturersService, private activatedRoute: ActivatedRoute, private router: Router) {
  }

  public ngOnInit() {
    this.form = new FormGroup({
      manufacturerId: new FormControl(''),
      name: new FormControl(''),
    });

    this.activatedRoute.params.forEach((params: Params) => {
      let id = params['id'];

      if (id == 0) {
        this.initializeInputs();
        return;
      }

      this.manufacturersService.getById(id)
        .pipe(takeUntil(this.stop$))
        .subscribe((result: ManufacturerModel) => this.initializeInputs(result), error => console.log(error));
    });
  }

  public ngOnDestroy() {
    this.stop$.next();
    this.stop$.complete();
  }

  public onSubmit() {
    let result = this.form.value;

    if (this.model.manufacturerId != 0) {
      this.manufacturersService.update(result.manufacturerId, result)
        .pipe(takeUntil(this.stop$))
        .subscribe(() => this.redirectToParent());

      return;
    }

    this.manufacturersService.create(result)
      .pipe(takeUntil(this.stop$))
      .subscribe(() => this.redirectToParent());
  }

  public header() {
    return this.model.manufacturerId == 0 ? 'Create manufacturer' : 'Update manufacturer';
  }

  private redirectToParent() {
    return this.router.navigate(['/manufacturers']);
  }

  private initializeInputs(model: ManufacturerModel = {name: '', manufacturerId: 0}) {
    this.model = model;
    this.form.patchValue(this.model);
    this.isInitialized = true;
  }
}
