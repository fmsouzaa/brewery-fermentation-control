export interface FermentationRecord {
    id: number
    dateTime: string
    beerId: number
    tankId: number
    batchNumber: string
    temperature: number
    ph: number
    extract: number
    notes: string
    category: number
}