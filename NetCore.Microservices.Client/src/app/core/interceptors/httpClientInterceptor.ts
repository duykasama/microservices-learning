import { HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { inject } from "@angular/core";
import { Observable } from "rxjs";
import { endpoint } from "src/environments/endpoints";
import { environment } from "src/environments/evironment";
import { AuthService } from "../guards/auth.service";
import { getLocalAccessToken } from "../lib/helpers";

export class HttpClientInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (!req.url.includes('http')) {
            req = req.clone({
                url: `${environment.API_BASE_URL}/${endpoint.PREFIX}/${req.url}`,
                setHeaders: {
                    'Authorization': `Bearer ${getLocalAccessToken()}`
                }
            });
        }

        return next.handle(req);
    }
}