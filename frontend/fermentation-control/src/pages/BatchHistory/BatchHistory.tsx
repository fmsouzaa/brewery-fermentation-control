// BatchHistory.tsx - Histórico de registros por lote
import { useState } from 'react'
import type { FermentationRecordDetail } from '../../types/FermentationRecordDetail'
import { getRecordsByBatch } from '../../services/fermentationService'
import { categoryLabels, categoryColors } from '../../utils/categoryUtils'
import { toTitleCase } from '../../utils/textFormatterUtils'
import styles from './BatchHistory.module.css'

const BatchHistory = () => {
  const [batchNumber, setBatchNumber] = useState('')
  const [records, setRecords] = useState<FermentationRecordDetail[]>([])
  const [searched, setSearched] = useState(false)
  const [searchedBatch, setSearchedBatch] = useState('')

  const handleSearch = (e: React.FormEvent) => {
  e.preventDefault()
  getRecordsByBatch(batchNumber)
    .then(response => {
      setRecords(response.data)
      setSearched(true)
      setSearchedBatch(batchNumber) // guarda o lote buscado
    })
    .catch(() => {
      setRecords([])
      setSearched(true)
      setSearchedBatch(batchNumber)
    })

    
  }

  return (
    <div className={styles.container}>
      <h1 className={styles.title}>Histórico de Lotes</h1>

      {/* Busca por número do lote */}
      <div className={styles.card}>
        <h2 className={styles.subtitle}>Buscar Lote</h2>
        <form onSubmit={handleSearch} className={styles.form}>
          <div className={styles.searchRow}>
            <input
              className={styles.input}
              type="text"
              value={batchNumber}
              onChange={e => setBatchNumber(e.target.value)}
              placeholder="Ex: LOTE001"
              required
            />
            <button type="submit" className={styles.button}>Buscar</button>
          </div>
        </form>
      </div>

      {/* Resultado da busca quando não é encontrado nenhum*/}
      {searched && records.length === 0 && (
        <div className={styles.empty}>
            Nenhum registro encontrado para o lote {searchedBatch}.
        </div>
      )}

      {/* Lista da fermentação */}
      {records.length > 0 && (
        <div className={styles.card}>
          <h2 className={styles.subtitle}>
            Lote: {searchedBatch} — {records.length} registro(s)
          </h2>
          <table className={styles.table}>
            <thead>
              <tr>
                <th className={styles.th}>Data e Hora</th>
                <th className={styles.th}>Cerveja</th>
                <th className={styles.th}>Tanque</th>
                <th className={styles.th}>Temperatura</th>
                <th className={styles.th}>pH</th>
                <th className={styles.th}>Extrato</th>
                <th className={styles.th}>Classificação</th>
              </tr>
            </thead>
            <tbody>
              {records.map(record => (
                <tr key={record.id} className={styles.tr}>
                  <td className={styles.td}>
                    {new Date(record.dateTime).toLocaleString('pt-BR')}
                  </td>
                  <td className={styles.td}>{toTitleCase(record.beerName)}</td>
                  <td className={styles.td}>{toTitleCase(record.tankName)}</td>
                  <td className={styles.td}>{record.temperature}°C</td>
                  <td className={styles.td}>{record.ph}</td>
                  <td className={styles.td}>{record.extract}</td>
                  <td className={styles.td}>
                    <span className={`${styles.badge} ${styles[categoryColors[record.category]]}`}>
                      {categoryLabels[record.category]}
                    </span>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
    </div>
  )
}

export default BatchHistory