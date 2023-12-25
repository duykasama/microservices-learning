import {animate, style, transition, trigger} from "@angular/animations";

export const ToastTransitionAnimation = [
    trigger('open', [
        transition(':enter', [
            style({
                transform: 'translateX(100%)',
                opacity: '0'
            }),
            animate('250ms ease-out',
            style({
                transform: 'translateX(0)',
                opacity: '1'
            }))
        ])
    ]),
    trigger('close', [
    transition(':leave', [
        style({
            transform: 'translateX(0)',
            opacity: '1'
        }),
        animate('250ms ease-in',
        style({
            transform: 'translateX(100%)',
            opacity: '0'
        }))
    ])
    ])
];