import { fetchPopularTracks } from "@/entities/track"
import type { LoaderFunctionArgs } from "react-router"

export const homeLoader = async({ request }: LoaderFunctionArgs) => {
    const response = await fetchPopularTracks(10, request.signal)
    return response
}