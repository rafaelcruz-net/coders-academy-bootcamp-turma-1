import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { MusicRoutingModule } from "./music-routing.module";
import { MusicComponent } from "./music.component";
import { FuseSharedModule } from "@fuse/shared.module";
import { MatButtonModule } from "@angular/material";
import { MusicDetailComponent } from './music-detail/music-detail.component';

@NgModule({
    declarations: [MusicComponent, MusicDetailComponent],
    imports: [
        CommonModule,
        MusicRoutingModule,
        FuseSharedModule,
        MatButtonModule,
    ],
})
export class MusicModule {}
