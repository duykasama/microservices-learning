import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from '../store/AppState';
import { addToast, removeToast } from '../store/toast/toast.actions';
import { SingleToast } from '../store/toast/toast.reducers';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  success(content: string, title: string): void {
    this.displayToast(content, title, 'success');
  }
  
  error(content: string, title: string): void {
    this.displayToast(content, title, 'error');
  }
  
  private displayToast(content: string, title: string, status: 'success' | 'warning' | 'error'): void {
    const id: string = Guid.create().toString();
    const toast: SingleToast = {
      id,
      title,
      content,
      status,
    };
  
    this.store$.dispatch(addToast({toast}));
  
    setTimeout(() => this.store$.dispatch(removeToast({id})), 3000);    
  }

  constructor(
    private store$: Store<AppState>
  ) { }
}
