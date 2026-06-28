// Tanks.tsx - Cadastro e listagem de tanques
import { useEffect, useState } from 'react'
import type { Tank } from '../../types/Tank'
import { getAllTanks, createTank } from '../../services/tankService'
import styles from './Tanks.module.css'
import { toTitleCase } from '../../utils/textFormatterUtils'

const Tanks = () => {
  // Lista de tanques
  const [tanks, setTanks] = useState<Tank[]>([])
  // Campos do formulário
  const [name, setName] = useState('')
  const [capacity, setCapacity] = useState('')

  // Busca os tanques quando a página carrega
  useEffect(() => {
    loadTanks()
  }, [])

  const loadTanks = () => {
    getAllTanks().then(response => {
      setTanks(response.data)
    })
  }

  // Salva um novo tanque
  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault()
    createTank({ name, capacity: Number(capacity) }).then(() => {
      setName('')
      setCapacity('')
      loadTanks()
    })
  }

  return (
    <div className={styles.container}>
      <h1 className={styles.title}>Tanques</h1>
    
        {/* Formulário de cadastro */}
        <div className={styles.card}>
            <h2 className={styles.subtitle}>Novo Tanque</h2>
            <form onSubmit={handleSubmit} className={styles.form}>
            <div className={styles.field}>
                <label className={styles.label}>Nome</label>
                <input
                className={styles.input}
                type="text"
                value={name}
                onChange={e => setName(e.target.value)}
                placeholder="Ex: Tank 0001"
                required
                />
            </div>

            <div className={styles.field}>
                <label className={styles.label}>Capacidade (Litros)</label>
                <input
                className={styles.input}
                type="number"
                value={capacity}
                onChange={e => setCapacity(e.target.value)}
                placeholder="Ex: 1000"
                required
                />
            </div>

            <button type="submit" className={styles.button}>
                Salvar
            </button>
            </form>
        </div>
        {/* Lista de cervejas cadastradas */}
        <div className={styles.card}>
            <h2 className={styles.subtitle}>Tanques Cadastrados</h2>
            <table className={styles.table}>
            <thead>
                <tr>
                <th className={styles.th}>Nome</th>
                <th className={styles.th}>Capacidade (L)</th>
                </tr>
            </thead>
            <tbody>
                {tanks.map(tank => (
                <tr key={tank.id} className={styles.tr}>
                    <td className={styles.td}>{toTitleCase(tank.name)}</td>
                    <td className={styles.td}>{tank.capacity}</td>
                </tr>
                ))}
            </tbody>
            </table>
        </div>
    </div>
  )
}

export default Tanks