import axios from 'axios';
import { Breed } from '../models/Breed';
import { PaginatedResponse } from '../shared/PaginatedResponse';

const apiBaseUrl = process.env.VUE_APP_API_BASE_URL;

export async function fetchDogsBreeds(
  pageNumber: number = 1,
  pageSize: number = 10,
  name: string = '') : Promise<PaginatedResponse<Breed>> {
    const response = await axios.get(`${apiBaseUrl}/dogs/breeds`, {
      params: { pageNumber, pageSize, name }
    });

    return {
      pageNumber: response.data.pageNumber,
      totalPages: response.data.totalPages,
      totalCount: response.data.totalCount,
      pageSize: response.data.pageSize,
      items: response.data.items.map((item: any) => ({
        id: item.id,
        breedName: item.attributes.breedName,
        breedDescription: item.attributes.breedDescription,
        lifeRange: item.attributes.lifeRange,
        maleWeightRange: item.attributes.maleWeightRange,
        femaleWeightRange: item.attributes.femaleWeightRange,
        hypoallergenic: item.attributes.hypoallergenic
      }))
    };
}