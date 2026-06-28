export interface FermentationRecordDetail {
    id: number
    dateTime: string
    beerName: string
    tankName: string
    batchNumber: string
    temperature: number
    ph: number
    extract: number
    notes: string | null
    category: number
}