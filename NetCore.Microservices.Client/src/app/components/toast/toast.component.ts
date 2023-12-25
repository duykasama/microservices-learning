import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, map } from 'rxjs';
import { ToastTransitionAnimation } from 'src/app/core/animations/toast-transition.animation';
import { AppState } from 'src/app/core/store/AppState';
import { removeToast } from 'src/app/core/store/toast/toast.actions';
import { SingleToast } from 'src/app/core/store/toast/toast.reducers';
import { selectAllToasts } from 'src/app/core/store/toast/toast.selectors';
import { faCheck, faCircleExclamation } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-toast',
  templateUrl: './toast.component.html',
  animations: ToastTransitionAnimation
})
export class ToastComponent implements OnInit {

  show$!: Observable<boolean>;
  toastList$!: Observable<SingleToast[]>;

  
  ngOnInit(): void {
    this.toastList$ = this.store.select(selectAllToasts);
  }
  
  closeToast(id: string): void {
    this.store.dispatch(removeToast({id}));  
  }

  constructor(private store: Store<AppState>) {
  }

  faCheck = faCheck;
  faCircleExclamation = faCircleExclamation;
}
