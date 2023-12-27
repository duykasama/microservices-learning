import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Subject, takeUntil } from 'rxjs';
import { ToastService } from 'src/app/core/services/toast.service';
import { AppState } from 'src/app/core/store/AppState';
import { addToast, removeToast } from 'src/app/core/store/toast/toast.actions';
import { SingleToast } from 'src/app/core/store/toast/toast.reducers';
import { selectAllToasts } from 'src/app/core/store/toast/toast.selectors';

@Component({
  selector: 'app-test-toast',
  templateUrl: './test-toast.component.html',
  styleUrls: ['./test-toast.component.scss']
})
export class TestToastComponent implements OnInit, OnDestroy {

  destroy$: Subject<void> = new Subject<void>();
  toastCount: number = 0;

  ngOnInit(): void {
    this.store.select(selectAllToasts).pipe(takeUntil(this.destroy$)).subscribe(allToasts => this.toastCount = allToasts.length)
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  addToast(): void {
    this.toastService.success('This is a toast', 'Success');
  }

  addErrorToast(): void {
    this.toastService.error('This is an error toast', 'Error');
  }

  constructor(
    private store: Store<AppState>,
    private toastService: ToastService
  ) { }
}
