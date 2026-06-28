export interface FermentationParameter {
    id: number
    beerId: number
    temperatureMin: number
    temperatureMax: number 
    temperatureTolerance: number 
    pHMin: number 
    pHMax: number
    pHTolerance: number
    extractMin: number
    extractMax: number
    extractTolerance: number
}