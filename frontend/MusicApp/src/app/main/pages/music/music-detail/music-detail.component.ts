import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import Album from "app/model/album";
import { MusicService } from "app/services/music.service";

@Component({
    selector: "app-music-detail",
    templateUrl: "./music-detail.component.html",
    styleUrls: ["./music-detail.component.scss"],
})
export class MusicDetailComponent implements OnInit {
    albumId: String = undefined;
    album: Album = undefined;

    constructor(
        private musicService: MusicService,
        private activeRoute: ActivatedRoute,
        private router: Router
    ) {}

    ngOnInit() {
        this.albumId = this.activeRoute.snapshot.paramMap.get("id");
        this.musicService.getAlbumDetail(this.albumId).subscribe((data) => {
            this.album = data;
        });
    }

    back() {
        this.router.navigate(["music"]);
    }
}
