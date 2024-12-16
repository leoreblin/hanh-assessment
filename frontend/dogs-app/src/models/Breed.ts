export interface Breed {
  id: string;
  breedName: string;
  breedDescription: string;
  lifeRange: { min: number; max: number };
  maleWeightRange: { min: number; max: number };
  femaleWeightRange: { min: number; max: number };
  hypoallergenic: boolean;
}