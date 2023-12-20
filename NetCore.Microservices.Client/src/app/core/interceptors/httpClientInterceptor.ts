import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Observable } from "rxjs";
import { endpoint } from "src/environments/endpoints";
import { environment } from "src/environments/evironment";

export class HttpClientInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (!req.url.includes('http')) {
            req = req.clone({
                url: environment.API_BASE_URL + endpoint.PREFIX + req.url
            });
        }

        return next.handle(req);
    }
}