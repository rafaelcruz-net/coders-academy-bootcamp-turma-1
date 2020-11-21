import { NgModule } from "@angular/core";

import { LoginModule } from "app/main/pages/authentication/login/login.module";
import { RegisterModule } from "app/main/pages/authentication/register/register.module";
import { FavoriteModule } from "./favorite/favorite.module";
import { MusicModule } from "./music/music.module";

@NgModule({
    imports: [LoginModule, RegisterModule, FavoriteModule, MusicModule],
    declarations: [],
})
export class PagesModule {}
