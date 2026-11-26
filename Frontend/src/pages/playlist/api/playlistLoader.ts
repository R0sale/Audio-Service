import { fetchPlaylist } from '@/entities/playlist'
import type { LoaderFunctionArgs } from 'react-router';

export const playlistLoader = async ({ params, request }: LoaderFunctionArgs) => {
    const playlistId = params.id;

    if (playlistId === undefined) {
        throw new Error('Playlist ID is undefined');
    }

    const response = await fetchPlaylist(playlistId, request.signal);
    
    return response;
}