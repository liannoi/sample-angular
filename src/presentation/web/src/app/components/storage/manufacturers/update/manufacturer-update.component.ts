import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';

import {ManufacturerModel, ManufacturersService} from '../../../../../api/sample-angular-api';

@Component({
  selector: 'app-manufacturer-update',
  templateUrl: './manufacturer-update.component.html',
  styleUrls: ['./manufacturer-update.component.css'],
  providers: [ManufacturersService],
})
export class ManufacturerUpdateComponent implements OnInit, OnDestroy {
  public form: FormGroup;
  public model: ManufacturerModel;
  private stop$ = new Subject<void>();
  private errorMessage: string;

  constructor(private manufacturersService: ManufacturersService, private activatedRoute: ActivatedRoute, private router: Router) {
  }

  public ngOnInit(): void {
    this.form = new FormGroup({
      manufacturerId: new FormControl(''),
      name: new FormControl(''),
    });

    this.activatedRoute.params.forEach((params: Params) => {
      let id = params['id'];

      if (id > 0) {
        this.manufacturersService.getById(id)
          .pipe(takeUntil(this.stop$))
          .subscribe((result: ManufacturerModel) => {
            this.model = result;
            this.form.patchValue(this.model);
          }, error => this.errorMessage = error);
      } else {
        this.model = new ManufacturerModel();
        this.form.patchValue(this.model);
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
        .subscribe(() => this.router.navigate(['/manufacturers']));
    } else {
      this.manufacturersService.create(result)
        .pipe(takeUntil(this.stop$))
        .subscribe(() => this.router.navigate(['/manufacturers']));
    }
  }
}
