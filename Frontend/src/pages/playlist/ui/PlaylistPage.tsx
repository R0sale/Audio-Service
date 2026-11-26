import { PlayPlaylistButton } from "@/features/play-playlist"
import { useLoaderData } from "react-router"
import type { playlistLoader } from "../api/playlistLoader"
import { TrackList } from "@/widgets/track-list"


export const PlaylistPage = () => {
    const playlist = useLoaderData<typeof playlistLoader>()

    return (
        <>
            <header className="relative isolate flex min-h-72 items-end overflow-hidden bg-linear-to-b from-accent/70 via-accent/35 to-accent/15 px-6 pt-24 pb-6 before:absolute before:inset-0 before:-z-5 before:bg-linear-to-t before:from-surface-raised before:via-black/50 before:to-black/10 md:rounded-t-lg">
                <img
                    src={playlist.coverUrl ?? undefined}
                    alt=""
                    aria-hidden="true"
                    className="absolute inset-0 -z-10 size-full scale-110 object-cover blur-[2px]"
                />
                <div className="flex flex-col gap-3 [&>button]:order-last [&>button]:mt-4 [&>button]:size-14! [&>button_svg]:size-6">
                    <PlayPlaylistButton playlist={playlist} />
                    <div className="line-clamp-2 text-4xl font-extrabold tracking-tight text-white drop-shadow-md sm:text-5xl md:text-6xl">{playlist.title}</div>
                    <div className="max-w-2xl text-sm text-zinc-200/80 sm:text-base">{playlist.description}</div>
                </div>
            </header>
            <div className="bg-linear-to-b from-accent/15 to-surface-raised to-30% px-3 pt-4 pb-8 sm:px-6 md:rounded-b-lg">
                <TrackList tracks={playlist.tracks.map((t) => t.track)} queueId={playlist.id} />
            </div>
        </>
    )
}