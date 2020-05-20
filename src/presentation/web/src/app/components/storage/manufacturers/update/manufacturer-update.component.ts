import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';

import {ManufacturersService} from '../../../../../api/services/manufacturers.service';
import {ManufacturerModel} from '../../../../../api/models/manufacturer.model';

@Component({
  selector: 'app-manufacturer-update',
  templateUrl: './manufacturer-update.component.html',
  providers: [ManufacturersService],
})
export class ManufacturerUpdateComponent implements OnInit, OnDestroy {
  public form: FormGroup;
  public model: ManufacturerModel;
  private stop$ = new Subject<void>();

  constructor(private manufacturersService: ManufacturersService, private activatedRoute: ActivatedRoute, private router: Router) {
  }

  public ngOnInit(): void {
    this.form = new FormGroup({
      manufacturerId: new FormControl(''),
      name: new FormControl(''),
    });

    this.activatedRoute.params.forEach((params: Params) => {
      let id = params['id'];

      if (id != 0) {
        this.manufacturersService.getById(id)
          .pipe(takeUntil(this.stop$))
          .subscribe((result: ManufacturerModel) => this.initializeInputs(result), error => console.log(error));
      } else {
        this.initializeInputs();
      }
    });
  }

  public ngOnDestroy(): void {
    this.stop$.next();
    this.stop$.complete();
  }

  public onSubmit(): void {
    let result = this.form.value;

    if (this.model.manufacturerId != 0) {
      this.manufacturersService.update(result.manufacturerId, result)
        .pipe(takeUntil(this.stop$))
        .subscribe(() => this.redirectToParent());
    } else {
      this.manufacturersService.create(result)
        .pipe(takeUntil(this.stop$))
        .subscribe(() => this.redirectToParent());
    }
  }

  private redirectToParent(): Promise<boolean> {
    return this.router.navigate(['/manufacturers']);
  }

  private initializeInputs(model: ManufacturerModel = new ManufacturerModel()): void {
    this.model = model;
    this.form.patchValue(this.model);
  }
}
