// Beers.tsx - Cadastro e listagem de cervejas
import { useEffect, useState } from 'react'
import type { Beer } from '../../types/Beer'
import { getAllBeers, createBeer } from '../../services/beerService'
import styles from './Beers.module.css'
import { toTitleCase } from '../../utils/textFormatterUtils'
import Alert from '../../components/Ui/Alert/Alert'

const Beers = () => {
  // Lista de cervejas
  const [beers, setBeers] = useState<Beer[]>([])
  // Campos do formulário
  const [name, setName] = useState('')
  const [style, setStyle] = useState('')

  //Mensagem de sucesso ou erro
  const [success, setSuccess] = useState(false)
  const [error, setError] = useState('')

  // Busca as cervejas quando a página carrega
  useEffect(() => {
    loadBeers()
  }, [])

  const loadBeers = () => {
    getAllBeers().then(response => {
      setBeers(response.data)
    })
  }

  // Salva uma nova cerveja
  const handleSubmit = (e: React.FormEvent) => {
  e.preventDefault()
  setError('')
  setSuccess(false)
  createBeer({ name, style })
    .then(() => {
      setSuccess(true)
      setName('')
      setStyle('')
      loadBeers()
    })
    .catch(() => {
      setError('Erro ao salvar a cerveja. Tente novamente.')
    })
}

  return (
    <div className={styles.container}>
      <h1 className={styles.title}>Cervejas</h1>

      {/* Formulário de cadastro */}
      <div className={styles.card}>
        <h2 className={styles.subtitle}>Nova Cerveja</h2>
        <form onSubmit={handleSubmit} className={styles.form}>
          <div className={styles.field}>
            <label className={styles.label}>Nome</label>
            <input
              className={styles.input}
              type="text"
              value={name}
              onChange={e => setName(e.target.value)}
              placeholder="Ex: Cerveja Clássica"
              required
            />
          </div>

          <div className={styles.field}>
            <label className={styles.label}>Estilo</label>
            <input
              className={styles.input}
              type="text"
              value={style}
              onChange={e => setStyle(e.target.value)}
              placeholder="Ex: Lager"
              required
            />
          </div>

          <button type="submit" className={styles.button}>Salvar</button>
          {success && <Alert type="success" message="Cerveja salva com sucesso!" onClose={() => setSuccess(false)} />}
          {error && <Alert type="error" message={error} onClose={() => setError('')} />}

        </form>
      </div>

      {/* Lista de cervejas cadastradas */}
      <div className={styles.card}>
        <h2 className={styles.subtitle}>Cervejas Cadastradas</h2>
        <table className={styles.table}>
          <thead>
            <tr>
              <th className={styles.th}>Nome</th>
              <th className={styles.th}>Estilo</th>
            </tr>
          </thead>
          <tbody>
            {beers.map(beer => (
              <tr key={beer.id} className={styles.tr}>
                <td className={styles.td}>{toTitleCase(beer.name)}</td>
                <td className={styles.td}>{toTitleCase(beer.style)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  )
}

export default Beers