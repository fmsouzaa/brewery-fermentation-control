// FermentationParameter.tsx - Cadastro de parâmetros aceitáveis por cerveja
import { useEffect, useState } from 'react'
import type { FermentationParameter } from '../../types/FermentationParameter'
import type { Beer } from '../../types/Beer'
import { getParameterByBeerId, createParameter } from '../../services/parameterService'
import { getAllBeers } from '../../services/beerService'
import styles from './FermentationParameter.module.css'
import { toTitleCase } from '../../utils/textFormatterUtils'

const FermentationParameterPage = () => {
  const [beers, setBeers] = useState<Beer[]>([])
  const [parameter, setParameter] = useState<FermentationParameter | null>(null)
  const [selectedBeerId, setSelectedBeerId] = useState<number>(0)

  // Campos do formulário
  const [temperatureMin, setTemperatureMin] = useState('')
  const [temperatureMax, setTemperatureMax] = useState('')
  const [temperatureTolerance, setTemperatureTolerance] = useState('')
  const [phMin, setPhMin] = useState('')
  const [phMax, setPhMax] = useState('')
  const [phTolerance, setPhTolerance] = useState('')
  const [extractMin, setExtractMin] = useState('')
  const [extractMax, setExtractMax] = useState('')
  const [extractTolerance, setExtractTolerance] = useState('')

  // Busca as cervejas para o dropdown
  useEffect(() => {
    getAllBeers().then(response => setBeers(response.data))
  }, [])

  // Busca os parâmetros quando seleciona uma cerveja
  useEffect(() => {
    if (selectedBeerId > 0) {
      getParameterByBeerId(selectedBeerId)
        .then(response => setParameter(response.data))
        .catch(() => setParameter(null))
    }
  }, [selectedBeerId])

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault()
    createParameter({
      beerId: selectedBeerId,
      temperatureMin: Number(temperatureMin),
      temperatureMax: Number(temperatureMax),
      temperatureTolerance: Number(temperatureTolerance),
      phMin: Number(phMin),
      phMax: Number(phMax),
      phTolerance: Number(phTolerance),
      extractMin: Number(extractMin),
      extractMax: Number(extractMax),
      extractTolerance: Number(extractTolerance),
    }).then(() => {
      getParameterByBeerId(selectedBeerId).then(response => setParameter(response.data))
    })
  }

  return (
    <div className={styles.container}>
      <h1 className={styles.title}>Parâmetros de Fermentação</h1>

      {/* Formulário de cadastro */}
      <div className={styles.card}>
        <h2 className={styles.subtitle}>Novo Parâmetro</h2>
        <form onSubmit={handleSubmit} className={styles.form}>

          {/* Seleção de cerveja */}
          <div className={styles.field}>
            <label className={styles.label}>Cerveja</label>
            <select
              className={styles.input}
              value={selectedBeerId}
              onChange={e => setSelectedBeerId(Number(e.target.value))}
              required
            >
              <option value={0}>Selecione uma cerveja</option>
              {beers.map(beer => (
                <option key={beer.id} value={beer.id}>{toTitleCase(beer.name)}</option>
              ))}
            </select>
          </div>

          {/* Temperatura */}
          <div className={styles.fieldGroup}>
            <div className={styles.field}>
              <label className={styles.label}>Temperatura Mínima (°C)</label>
              <input className={styles.input} type="number" value={temperatureMin} onChange={e => setTemperatureMin(e.target.value)} required />
            </div>
            <div className={styles.field}>
              <label className={styles.label}>Temperatura Máxima (°C)</label>
              <input className={styles.input} type="number" value={temperatureMax} onChange={e => setTemperatureMax(e.target.value)} required />
            </div>
            <div className={styles.field}>
              <label className={styles.label}>Tolerância (°C)</label>
              <input className={styles.input} type="number" value={temperatureTolerance} onChange={e => setTemperatureTolerance(e.target.value)} required />
            </div>
          </div>

          {/* pH */}
          <div className={styles.fieldGroup}>
            <div className={styles.field}>
              <label className={styles.label}>pH Mínimo</label>
              <input className={styles.input} type="number" value={phMin} onChange={e => setPhMin(e.target.value)} required />
            </div>
            <div className={styles.field}>
              <label className={styles.label}>pH Máximo</label>
              <input className={styles.input} type="number" value={phMax} onChange={e => setPhMax(e.target.value)} required />
            </div>
            <div className={styles.field}>
              <label className={styles.label}>Tolerância pH</label>
              <input className={styles.input} type="number" value={phTolerance} onChange={e => setPhTolerance(e.target.value)} required />
            </div>
          </div>

          {/* Extrato */}
          <div className={styles.fieldGroup}>
            <div className={styles.field}>
              <label className={styles.label}>Extrato Mínimo</label>
              <input className={styles.input} type="number" value={extractMin} onChange={e => setExtractMin(e.target.value)} required />
            </div>
            <div className={styles.field}>
              <label className={styles.label}>Extrato Máximo</label>
              <input className={styles.input} type="number" value={extractMax} onChange={e => setExtractMax(e.target.value)} required />
            </div>
            <div className={styles.field}>
              <label className={styles.label}>Tolerância Extrato</label>
              <input className={styles.input} type="number" value={extractTolerance} onChange={e => setExtractTolerance(e.target.value)} required />
            </div>
          </div>

          <button type="submit" className={styles.button}>Salvar</button>
        </form>
      </div>

      {/* Parâmetros da cerveja selecionada */}
      {parameter && (
        <div className={styles.card}>
          <h2 className={styles.subtitle}>Parâmetros Cadastrados</h2>
          <table className={styles.table}>
            <thead>
              <tr>
                <th className={styles.th}>Parâmetro</th>
                <th className={styles.th}>Mínimo</th>
                <th className={styles.th}>Máximo</th>
                <th className={styles.th}>Tolerância</th>
              </tr>
            </thead>
            <tbody>
              <tr className={styles.tr}>
                <td className={styles.td}>Temperatura (°C)</td>
                <td className={styles.td}>{parameter.temperatureMin}</td>
                <td className={styles.td}>{parameter.temperatureMax}</td>
                <td className={styles.td}>{parameter.temperatureTolerance}</td>
              </tr>
              <tr className={styles.tr}>
                <td className={styles.td}>pH</td>
                <td className={styles.td}>{parameter.phMin}</td>
                <td className={styles.td}>{parameter.phMax}</td>
                <td className={styles.td}>{parameter.phTolerance}</td>
              </tr>
              <tr className={styles.tr}>
                <td className={styles.td}>Extrato</td>
                <td className={styles.td}>{parameter.extractMin}</td>
                <td className={styles.td}>{parameter.extractMax}</td>
                <td className={styles.td}>{parameter.extractTolerance}</td>
              </tr>
            </tbody>
          </table>
        </div>
      )}
    </div>
  )
}

export default FermentationParameterPage