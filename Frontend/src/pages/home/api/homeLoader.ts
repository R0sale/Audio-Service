import { fetchPopularTracks } from "@/entities/track"
import { fetchFeaturedPlaylists } from "@/entities/playlist"
import type { LoaderFunctionArgs } from "react-router"

export const homeLoader = async({ request }: LoaderFunctionArgs) => {
    const [popularTracks, featuredPlaylists] = await Promise.all([
        fetchPopularTracks(10, request.signal),
        fetchFeaturedPlaylists(5, request.signal)
    ])
    return { popularTracks, featuredPlaylists }
}