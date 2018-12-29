import { File } from './file';

export class Bun {
    id: number;
    name: string;
    description: string;
    price?: number;
    topPicture?: File;
    bottomPicture?: File;
    active: boolean;
}
