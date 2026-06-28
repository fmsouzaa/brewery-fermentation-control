// FermentationRecord.tsx - Registro de apontamentos fermentativos
import { useEffect, useState } from 'react'
import type { Beer } from '../../types/Beer'
import type { Tank } from '../../types/Tank'
import { createFermentationRecord } from '../../services/fermentationService'
import { getAllBeers } from '../../services/beerService'
import { getAllTanks } from '../../services/tankService'
import { toTitleCase } from '../../utils/textFormatterUtils'
import styles from './FermentationRecord.module.css'

const FermentationRecordPage = () => {
  const [beers, setBeers] = useState<Beer[]>([])
  const [tanks, setTanks] = useState<Tank[]>([])

  // Campos do formulário
  const [beerId, setBeerId] = useState<number>(0)
  const [tankId, setTankId] = useState<number>(0)
  const [batchNumber, setBatchNumber] = useState('')
  const [temperature, setTemperature] = useState('')
  const [ph, setPh] = useState('')
  const [extract, setExtract] = useState('')
  const [notes, setNotes] = useState('')
  const [dateTime, setDateTime] = useState('')

  useEffect(() => {
    getAllBeers().then(response => setBeers(response.data))
    getAllTanks().then(response => setTanks(response.data))
  }, [])

  //Mensagem de sucesso
  const [success, setSuccess] = useState(false)

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault()
    createFermentationRecord({
      beerId,
      tankId,
      batchNumber,
      temperature: Number(temperature),
      ph: Number(ph),
      extract: Number(extract),
      notes,
      dateTime,
      category: 0,
    }).then(() => {
        setSuccess(true)
        setBatchNumber('')
        setTemperature('')
        setPh('')
        setExtract('')
        setNotes('')
        setDateTime('')
        // Esconde a mensagem após 3 segundos
        setTimeout(() => setSuccess(false), 3000)
    })
  }

  return (
    <div className={styles.container}>
      <h1 className={styles.title}>Registro de Fermentação</h1>

      <div className={styles.card}>
        <h2 className={styles.subtitle}>Novo Registro</h2>
        <form onSubmit={handleSubmit} className={styles.form}>

          {/* Data e hora */}
          <div className={styles.field}>
            <label className={styles.label}>Data e Hora</label>
            <input
              className={styles.input}
              type="datetime-local"
              value={dateTime}
              onChange={e => setDateTime(e.target.value)}
              required
            />
          </div>

          {/* Cerveja e Tanque */}
          <div className={styles.fieldGroup}>
            <div className={styles.field}>
              <label className={styles.label}>Cerveja</label>
              <select
                className={styles.input}
                value={beerId}
                onChange={e => setBeerId(Number(e.target.value))}
                required
              >
                <option value={0}>Selecione uma cerveja</option>
                {beers.map(beer => (
                  <option key={beer.id} value={beer.id}>{toTitleCase(beer.name)}</option>
                ))}
              </select>
            </div>

            <div className={styles.field}>
              <label className={styles.label}>Tanque</label>
              <select
                className={styles.input}
                value={tankId}
                onChange={e => setTankId(Number(e.target.value))}
                required
              >
                <option value={0}>Selecione um tanque</option>
                {tanks.map(tank => (
                  <option key={tank.id} value={tank.id}>{toTitleCase(tank.name)}</option>
                ))}
              </select>
            </div>
          </div>

          {/* Número do lote */}
          <div className={styles.field}>
            <label className={styles.label}>Número do Lote</label>
            <input
              className={styles.input}
              type="text"
              value={batchNumber}
              onChange={e => setBatchNumber(e.target.value)}
              placeholder="Ex: LOTE001"
              required
            />
          </div>

          {/* Temperatura, pH e Extrato */}
          <div className={styles.fieldGroup}>
            <div className={styles.field}>
              <label className={styles.label}>Temperatura (°C)</label>
              <input
                className={styles.input}
                type="number"
                value={temperature}
                onChange={e => setTemperature(e.target.value)}
                required
              />
            </div>
            <div className={styles.field}>
              <label className={styles.label}>pH</label>
              <input
                className={styles.input}
                type="number"
                value={ph}
                onChange={e => setPh(e.target.value)}
                required
              />
            </div>
            <div className={styles.field}>
              <label className={styles.label}>Extrato</label>
              <input
                className={styles.input}
                type="number"
                value={extract}
                onChange={e => setExtract(e.target.value)}
                required
              />
            </div>
          </div>

          {/* Observações */}
          <div className={styles.field}>
            <label className={styles.label}>Observações</label>
            <textarea
              className={styles.input}
              value={notes}
              onChange={e => setNotes(e.target.value)}
              placeholder="Observações opcionais"
              rows={3}
            />
          </div>

          <button type="submit" className={styles.button}>Salvar</button>
        </form>
      </div>

      {/* Lista de registros salvos na sessão */}
      {success && (
        <div className={styles.successMessage}>
            Registro salvo com sucesso!
        </div>
        )}
    </div>
  )
}

export default FermentationRecordPage