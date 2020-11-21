import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import Album from "app/model/album";
import { environment } from "environments/environment";
import { Observable } from "rxjs";

@Injectable({
    providedIn: "root",
})
export class MusicService {
    constructor(private http: HttpClient) {}

    public getAlbuns(): Observable<Album[]> {
        return this.http.get<Album[]>(`${environment.baseUrl}album`);
    }

    public getAlbumDetail(id: String): Observable<Album> {
        return this.http.get<Album>(`${environment.baseUrl}album/${id}`);
    }
}
