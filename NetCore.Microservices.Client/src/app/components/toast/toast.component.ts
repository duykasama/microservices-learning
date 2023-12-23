import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, map } from 'rxjs';
import { AppState } from 'src/app/core/store/AppState';
import { SingleToast } from 'src/app/core/store/toast/toast.reducers';
import { selectAllToasts, selectToastVisibility } from 'src/app/core/store/toast/toast.selectors';

@Component({
  selector: 'app-toast',
  templateUrl: './toast.component.html',
})
export class ToastComponent implements OnInit {

  show$!: Observable<boolean>;

  constructor(private store: Store<AppState>) {
  }

  ngOnInit(): void {
    this.show$ = this.store.select(selectToastVisibility);
  }
}
