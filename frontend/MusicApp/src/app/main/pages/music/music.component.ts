import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import Album from "app/model/album";
import { MusicService } from "app/services/music.service";

@Component({
    selector: "app-music",
    templateUrl: "./music.component.html",
    styleUrls: ["./music.component.scss"],
})
export class MusicComponent implements OnInit {
    albums: Album[] = [];

    constructor(private musicService: MusicService, private router: Router) {}

    ngOnInit() {
        this.musicService.getAlbuns().subscribe((result) => {
            this.albums = result;
        });
    }

    detail(album) {
        this.router.navigate(["music", album.id]);
    }
}
