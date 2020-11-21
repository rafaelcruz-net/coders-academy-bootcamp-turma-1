import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { MusicDetailComponent } from "./music-detail/music-detail.component";
import { MusicComponent } from "./music.component";

const routes: Routes = [
    {
        path: "music",
        component: MusicComponent,
    },
    {
        path: "music/:id",
        component: MusicDetailComponent,
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class MusicRoutingModule {}
