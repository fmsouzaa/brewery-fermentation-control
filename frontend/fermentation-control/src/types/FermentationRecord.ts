export interface FermentationRecord {
    id: number 
    dateTime: string 
    beerId: number 
    tankId: number 
    batchNumber: number 
    temperature: number 
    pH: number
    extract: number 
    notes: string 
    category: number 
}