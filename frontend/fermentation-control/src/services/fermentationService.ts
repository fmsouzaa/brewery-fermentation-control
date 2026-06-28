import api from './api'
import type { FermentationRecord } from '../types/FermentationRecord'

// Busca registros por número do lote
export const getRecordsByBatch = (batchNumber: string) => api.get<FermentationRecord[]>(`/api/FermentationRecord/batch/${batchNumber}`)

// Cria um novo registro de fermentação
export const createFermentationRecord = (record: Omit<FermentationRecord, 'id'>) => api.post('/api/FermentationRecord', record)