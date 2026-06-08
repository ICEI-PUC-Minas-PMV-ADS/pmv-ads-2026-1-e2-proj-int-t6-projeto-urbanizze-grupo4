/* ═══════════════════════════════════════════════════════
   pesquisa.js — Lógica de pesquisa e filtros
   RF-12: Denúncias  |  RF-13: Funcionários
═══════════════════════════════════════════════════════ */

/* ─────────────────────────────────────────
   DADOS MOCK
   Quando o colega implementar o RF-07 (Gerenciar Denúncias),
   basta substituir o array `DENUNCIAS` pela chamada à API dele.
   Ex: const DENUNCIAS = await fetchDenuncias();
   A lógica de filtro abaixo continuará funcionando sem alteração.
───────────────────────────────────────── */

const DENUNCIAS = [
  { id: 'URB-0024', titulo: 'Buraco na via', categoria: 'infraestrutura', bairro: 'centro',    bairroLabel: 'Centro',      data: '2026-06-04', status: 'aberto'    },
  { id: 'URB-0023', titulo: 'Iluminação pública apagada', categoria: 'iluminacao', bairro: 'savassi',   bairroLabel: 'Savassi',     data: '2026-06-01', status: 'andamento' },
  { id: 'URB-0022', titulo: 'Lixo acumulado na calçada', categoria: 'limpeza',     bairro: 'pampulha',  bairroLabel: 'Pampulha',    data: '2026-05-29', status: 'resolvido' },
  { id: 'URB-0021', titulo: 'Calçada danificada', categoria: 'acessibilidade', bairro: 'barreiro',  bairroLabel: 'Barreiro',    data: '2026-05-27', status: 'andamento' },
  { id: 'URB-0020', titulo: 'Vazamento de água', categoria: 'saneamento',    bairro: 'centro',    bairroLabel: 'Centro',      data: '2026-06-05', status: 'aberto'    },
  { id: 'URB-0019', titulo: 'Semáforo com defeito', categoria: 'transporte',   bairro: 'savassi',   bairroLabel: 'Savassi',     data: '2026-05-20', status: 'resolvido' },
  { id: 'URB-0018', titulo: 'Poste tombado', categoria: 'infraestrutura', bairro: 'venda-nova', bairroLabel: 'Venda Nova',   data: '2026-05-15', status: 'resolvido' },
  { id: 'URB-0017', titulo: 'Esgoto a céu aberto', categoria: 'saneamento',    bairro: 'barreiro',  bairroLabel: 'Barreiro',    data: '2026-05-10', status: 'andamento' },
  { id: 'URB-0016', titulo: 'Árvore bloqueando calçada', categoria: 'acessibilidade', bairro: 'pampulha',  bairroLabel: 'Pampulha',    data: '2026-05-08', status: 'aberto'    },
  { id: 'URB-0015', titulo: 'Lâmpada queimada na praça', categoria: 'iluminacao', bairro: 'centro',    bairroLabel: 'Centro',      data: '2026-05-05', status: 'resolvido' },
  { id: 'URB-0014', titulo: 'Ponto de ônibus danificado', categoria: 'transporte',   bairro: 'contagem',  bairroLabel: 'Contagem',    data: '2026-05-03', status: 'aberto'    },
  { id: 'URB-0013', titulo: 'Entulho descartado irregularmente', categoria: 'limpeza',     bairro: 'venda-nova', bairroLabel: 'Venda Nova',   data: '2026-04-28', status: 'resolvido' },
  { id: 'URB-0012', titulo: 'Cratera na Av. Principal', categoria: 'infraestrutura', bairro: 'contagem',  bairroLabel: 'Contagem',    data: '2026-04-22', status: 'andamento' },
  { id: 'URB-0011', titulo: 'Falta de rampa de acessibilidade', categoria: 'acessibilidade', bairro: 'savassi',   bairroLabel: 'Savassi',     data: '2026-04-18', status: 'aberto'    },
  { id: 'URB-0010', titulo: 'Cano rompido na rua lateral', categoria: 'saneamento',    bairro: 'centro',    bairroLabel: 'Centro',      data: '2026-04-10', status: 'resolvido' },
  { id: 'URB-0009', titulo: 'Lixo hospitalar descartado', categoria: 'limpeza',     bairro: 'pampulha',  bairroLabel: 'Pampulha',    data: '2026-04-05', status: 'andamento' },
  { id: 'URB-0008', titulo: 'Fios elétricos expostos', categoria: 'infraestrutura', bairro: 'barreiro',  bairroLabel: 'Barreiro',    data: '2026-03-30', status: 'resolvido' },
  { id: 'URB-0007', titulo: 'Sinalização apagada na curva', categoria: 'transporte',   bairro: 'venda-nova', bairroLabel: 'Venda Nova',   data: '2026-03-25', status: 'aberto'    },
  { id: 'URB-0006', titulo: 'Bueiro entupido causando alagamento', categoria: 'saneamento',    bairro: 'contagem',  bairroLabel: 'Contagem',    data: '2026-03-20', status: 'andamento' },
  { id: 'URB-0005', titulo: 'Pista com buracos múltiplos', categoria: 'infraestrutura', bairro: 'centro',    bairroLabel: 'Centro',      data: '2026-03-15', status: 'resolvido' },
  { id: 'URB-0004', titulo: 'Passagem bloqueada por obra', categoria: 'acessibilidade', bairro: 'savassi',   bairroLabel: 'Savassi',     data: '2026-03-10', status: 'aberto'    },
  { id: 'URB-0003', titulo: 'Descarte irregular de móveis', categoria: 'limpeza',     bairro: 'pampulha',  bairroLabel: 'Pampulha',    data: '2026-03-05', status: 'resolvido' },
  { id: 'URB-0002', titulo: 'Poste sem iluminação há 30 dias', categoria: 'iluminacao', bairro: 'barreiro',  bairroLabel: 'Barreiro',    data: '2026-02-28', status: 'resolvido' },
  { id: 'URB-0001', titulo: 'Calçada destruída por raízes', categoria: 'acessibilidade', bairro: 'venda-nova', bairroLabel: 'Venda Nova',   data: '2026-02-20', status: 'andamento' },
];

const FUNCIONARIOS = [
  { matricula: 'F-001', nome: 'Ana Paula Ferreira',    cargo: 'fiscal',       cargoLabel: 'Fiscal Urbano',     ocorrencias: 14, status: 'ativo'   },
  { matricula: 'F-002', nome: 'Bruno Carvalho',         cargo: 'engenheiro',   cargoLabel: 'Engenheiro',        ocorrencias: 8,  status: 'ativo'   },
  { matricula: 'F-003', nome: 'Carlos Eduardo Lima',    cargo: 'agente',       cargoLabel: 'Agente de Limpeza', ocorrencias: 3,  status: 'ativo'   },
  { matricula: 'F-004', nome: 'Daniela Souza',          cargo: 'coordenador',  cargoLabel: 'Coordenador',       ocorrencias: 21, status: 'ativo'   },
  { matricula: 'F-005', nome: 'Eduardo Nunes',          cargo: 'tecnico',      cargoLabel: 'Técnico',           ocorrencias: 6,  status: 'inativo' },
  { matricula: 'F-006', nome: 'Fernanda Ribeiro',       cargo: 'fiscal',       cargoLabel: 'Fiscal Urbano',     ocorrencias: 11, status: 'ativo'   },
  { matricula: 'F-007', nome: 'Gabriel Moraes',         cargo: 'agente',       cargoLabel: 'Agente de Limpeza', ocorrencias: 0,  status: 'inativo' },
  { matricula: 'F-008', nome: 'Helena Costa',           cargo: 'engenheiro',   cargoLabel: 'Engenheiro',        ocorrencias: 9,  status: 'ativo'   },
  { matricula: 'F-009', nome: 'Igor Andrade',           cargo: 'tecnico',      cargoLabel: 'Técnico',           ocorrencias: 4,  status: 'ativo'   },
  { matricula: 'F-010', nome: 'Juliana Melo',           cargo: 'coordenador',  cargoLabel: 'Coordenador',       ocorrencias: 17, status: 'ativo'   },
  { matricula: 'F-011', nome: 'Kleber Santos',          cargo: 'fiscal',       cargoLabel: 'Fiscal Urbano',     ocorrencias: 2,  status: 'inativo' },
  { matricula: 'F-012', nome: 'Larissa Oliveira',       cargo: 'agente',       cargoLabel: 'Agente de Limpeza', ocorrencias: 5,  status: 'ativo'   },
];

/* ─────────────────────────────────────────
   ESTADO DA APLICAÇÃO
───────────────────────────────────────── */
const state = {
  denuncias:    { page: 1, perPage: 8,  filtered: [...DENUNCIAS] },
  funcionarios: { page: 1, perPage: 8,  filtered: [...FUNCIONARIOS] },
};

/* ─────────────────────────────────────────
   HELPERS
───────────────────────────────────────── */

function today() { return new Date(); }

function daysAgo(n) {
  const d = today();
  d.setDate(d.getDate() - n);
  return d;
}

function parseDate(str) { return new Date(str); }

function highlight(text, query) {
  if (!query) return text;
  const re = new RegExp(`(${query.replace(/[.*+?^${}()|[\]\\]/g, '\\$&')})`, 'gi');
  return text.replace(re, '<mark>$1</mark>');
}

function formatDate(str) {
  const [y, m, d] = str.split('-');
  return `${d}/${m}/${y}`;
}

function statusLabel(s) {
  return { aberto: 'Aberto', andamento: 'Em andamento', resolvido: 'Resolvido' }[s] || s;
}

function statusBadgeClass(s) {
  return { aberto: 'badge-open', andamento: 'badge-progress', resolvido: 'badge-resolved' }[s] || '';
}

function categoriaLabel(c) {
  const map = {
    infraestrutura: 'Infraestrutura', iluminacao: 'Iluminação',
    limpeza: 'Limpeza urbana', saneamento: 'Saneamento',
    acessibilidade: 'Acessibilidade', transporte: 'Transporte',
  };
  return map[c] || c;
}

function occRangeMatch(n, range) {
  if (!range) return true;
  if (range === '0')   return n === 0;
  if (range === '1-5') return n >= 1 && n <= 5;
  if (range === '6-10')return n >= 6 && n <= 10;
  if (range === '11+') return n > 10;
  return true;
}

/* ─────────────────────────────────────────
   TABS
───────────────────────────────────────── */
function switchTab(tab) {
  document.querySelectorAll('.tab').forEach(t => t.classList.toggle('tab--active', t.dataset.tab === tab));
  document.getElementById('panel-denuncias').classList.toggle('panel--hidden',   tab !== 'denuncias');
  document.getElementById('panel-funcionarios').classList.toggle('panel--hidden', tab !== 'funcionarios');
}

/* ─────────────────────────────────────────
   RF-12 — FILTRO DE DENÚNCIAS
───────────────────────────────────────── */
function filterDenuncias() {
  const q        = document.getElementById('searchDenuncias').value.trim().toLowerCase();
  const status   = document.getElementById('filterStatus').value;
  const categoria= document.getElementById('filterCategoria').value;
  const periodo  = document.getElementById('filterPeriodo').value;
  const bairro   = document.getElementById('filterBairro').value;
  const sort     = document.getElementById('sortDenuncias').value;

  // show/hide clear button
  document.getElementById('clearDenuncias').classList.toggle('visible', q.length > 0);

  // highlight active selects
  ['filterStatus','filterCategoria','filterPeriodo','filterBairro'].forEach(id => {
    const el = document.getElementById(id);
    el.classList.toggle('active-filter', el.value !== '');
  });

  let result = DENUNCIAS.filter(d => {
    // texto
    if (q && !( d.titulo.toLowerCase().includes(q) ||
                d.categoria.toLowerCase().includes(q) ||
                d.bairroLabel.toLowerCase().includes(q) ||
                d.id.toLowerCase().includes(q) )) return false;
    // status
    if (status   && d.status    !== status)    return false;
    // categoria
    if (categoria && d.categoria !== categoria) return false;
    // bairro
    if (bairro   && d.bairro    !== bairro)    return false;
    // período
    if (periodo) {
      const date = parseDate(d.data);
      if (periodo === 'hoje'  && date < daysAgo(1))  return false;
      if (periodo === '7d'    && date < daysAgo(7))  return false;
      if (periodo === '30d'   && date < daysAgo(30)) return false;
      if (periodo === '90d'   && date < daysAgo(90)) return false;
    }
    return true;
  });

  // sort
  if (sort === 'antigo') result.sort((a,b) => a.data.localeCompare(b.data));
  else if (sort === 'titulo') result.sort((a,b) => a.titulo.localeCompare(b.titulo));
  else result.sort((a,b) => b.data.localeCompare(a.data));

  state.denuncias.filtered = result;
  state.denuncias.page = 1;
  renderDenuncias(q);
  renderChips('denuncias', { status, categoria, periodo, bairro });
}

function renderDenuncias(q = '') {
  const { filtered, page, perPage } = state.denuncias;
  const start = (page - 1) * perPage;
  const slice = filtered.slice(start, start + perPage);

  const tbody = document.getElementById('tbodyDenuncias');
  const empty = document.getElementById('emptyDenuncias');
  const info  = document.getElementById('resultInfoDenuncias');
  const count = document.getElementById('countDenuncias');

  count.textContent = filtered.length;
  info.innerHTML = `Mostrando <strong>${filtered.length}</strong> denúncia${filtered.length !== 1 ? 's' : ''}`;

  if (filtered.length === 0) {
    tbody.innerHTML = '';
    empty.style.display = 'block';
    document.getElementById('paginationDenuncias').innerHTML = '';
    return;
  }

  empty.style.display = 'none';

  tbody.innerHTML = slice.map((d, i) => `
    <tr style="animation-delay:${i * 0.04}s">
      <td><span class="tag-protocol">${highlight(d.id, q)}</span></td>
      <td>${highlight(d.titulo, q)}</td>
      <td>${highlight(categoriaLabel(d.categoria), q)}</td>
      <td>${highlight(d.bairroLabel, q)}</td>
      <td>${formatDate(d.data)}</td>
      <td><span class="occ-badge ${statusBadgeClass(d.status)}">${statusLabel(d.status)}</span></td>
      <!-- RF-07: célula de responsável será inserida aqui pelo colega -->
      <td><button class="btn-row-action">Ver detalhes</button></td>
    </tr>
  `).join('');

  renderPagination('denuncias');
}

/* ─────────────────────────────────────────
   RF-13 — FILTRO DE FUNCIONÁRIOS
───────────────────────────────────────── */
function filterFuncionarios() {
  const q         = document.getElementById('searchFuncionarios').value.trim().toLowerCase();
  const cargo     = document.getElementById('filterCargo').value;
  const statusF   = document.getElementById('filterStatusFunc').value;
  const ocorrFx   = document.getElementById('filterOcorrencias').value;
  const sort      = document.getElementById('sortFuncionarios').value;

  document.getElementById('clearFuncionarios').classList.toggle('visible', q.length > 0);

  ['filterCargo','filterStatusFunc','filterOcorrencias'].forEach(id => {
    const el = document.getElementById(id);
    el.classList.toggle('active-filter', el.value !== '');
  });

  let result = FUNCIONARIOS.filter(f => {
    if (q && !(f.nome.toLowerCase().includes(q) || f.matricula.toLowerCase().includes(q) || f.cargoLabel.toLowerCase().includes(q))) return false;
    if (cargo   && f.cargo  !== cargo)   return false;
    if (statusF && f.status !== statusF) return false;
    if (!occRangeMatch(f.ocorrencias, ocorrFx)) return false;
    return true;
  });

  if (sort === 'ocorrencias') result.sort((a,b) => b.ocorrencias - a.ocorrencias);
  else if (sort === 'cargo')  result.sort((a,b) => a.cargoLabel.localeCompare(b.cargoLabel));
  else result.sort((a,b) => a.nome.localeCompare(b.nome));

  state.funcionarios.filtered = result;
  state.funcionarios.page = 1;
  renderFuncionarios(q);
  renderChips('funcionarios', { cargo, status: statusF, ocorrencias: ocorrFx });
}

function renderFuncionarios(q = '') {
  const { filtered, page, perPage } = state.funcionarios;
  const start = (page - 1) * perPage;
  const slice = filtered.slice(start, start + perPage);

  const tbody = document.getElementById('tbodyFuncionarios');
  const empty = document.getElementById('emptyFuncionarios');
  const info  = document.getElementById('resultInfoFuncionarios');
  const count = document.getElementById('countFuncionarios');

  const MAX_OCC = Math.max(...FUNCIONARIOS.map(f => f.ocorrencias), 1);

  count.textContent = filtered.length;
  info.innerHTML = `Mostrando <strong>${filtered.length}</strong> funcionário${filtered.length !== 1 ? 's' : ''}`;

  if (filtered.length === 0) {
    tbody.innerHTML = '';
    empty.style.display = 'block';
    document.getElementById('paginationFuncionarios').innerHTML = '';
    return;
  }

  empty.style.display = 'none';

  tbody.innerHTML = slice.map((f, i) => `
    <tr style="animation-delay:${i * 0.04}s">
      <td><span class="tag-protocol">${highlight(f.matricula, q)}</span></td>
      <td>${highlight(f.nome, q)}</td>
      <td>${highlight(f.cargoLabel, q)}</td>
      <td>
        <div class="occ-count">
          <span>${f.ocorrencias}</span>
          <div class="occ-count-bar">
            <div class="occ-count-fill" style="width:${Math.round((f.ocorrencias/MAX_OCC)*100)}%"></div>
          </div>
        </div>
      </td>
      <td><span class="occ-badge ${f.status === 'ativo' ? 'badge-ativo' : 'badge-inativo'}">${f.status === 'ativo' ? 'Ativo' : 'Inativo'}</span></td>
      <td><button class="btn-row-action">Ver perfil</button></td>
    </tr>
  `).join('');

  renderPagination('funcionarios');
}

/* ─────────────────────────────────────────
   PAGINAÇÃO
───────────────────────────────────────── */
function renderPagination(type) {
  const s = state[type];
  const total = Math.ceil(s.filtered.length / s.perPage);
  const el = document.getElementById(`pagination${type.charAt(0).toUpperCase()+type.slice(1)}`);

  if (total <= 1) { el.innerHTML = ''; return; }

  let html = `<button class="page-btn" ${s.page===1?'disabled':''} onclick="goPage('${type}',${s.page-1})">‹</button>`;
  for (let i = 1; i <= total; i++) {
    html += `<button class="page-btn ${i===s.page?'page-btn--active':''}" onclick="goPage('${type}',${i})">${i}</button>`;
  }
  html += `<button class="page-btn" ${s.page===total?'disabled':''} onclick="goPage('${type}',${s.page+1})">›</button>`;
  el.innerHTML = html;
}

function goPage(type, page) {
  state[type].page = page;
  if (type === 'denuncias')    renderDenuncias(document.getElementById('searchDenuncias').value.trim().toLowerCase());
  if (type === 'funcionarios') renderFuncionarios(document.getElementById('searchFuncionarios').value.trim().toLowerCase());
  window.scrollTo({ top: 300, behavior: 'smooth' });
}

/* ─────────────────────────────────────────
   CHIPS DE FILTROS ATIVOS
───────────────────────────────────────── */
const CHIP_LABELS = {
  status:      { aberto: 'Aberto', andamento: 'Em andamento', resolvido: 'Resolvido', ativo: 'Ativo', inativo: 'Inativo' },
  categoria:   { infraestrutura:'Infraestrutura', iluminacao:'Iluminação', limpeza:'Limpeza', saneamento:'Saneamento', acessibilidade:'Acessibilidade', transporte:'Transporte' },
  periodo:     { hoje:'Hoje', '7d':'Últimos 7 dias', '30d':'Últimos 30 dias', '90d':'Últimos 90 dias' },
  bairro:      { centro:'Centro', savassi:'Savassi', pampulha:'Pampulha', barreiro:'Barreiro', 'venda-nova':'Venda Nova', contagem:'Contagem' },
  cargo:       { fiscal:'Fiscal Urbano', engenheiro:'Engenheiro', agente:'Agente de Limpeza', coordenador:'Coordenador', tecnico:'Técnico' },
  ocorrencias: { '0':'Sem ocorrências', '1-5':'1 a 5', '6-10':'6 a 10', '11+':'Mais de 10' },
};

function renderChips(type, activeFilters) {
  const container = document.getElementById(`chips${type.charAt(0).toUpperCase()+type.slice(1)}`);
  const chips = [];

  for (const [key, val] of Object.entries(activeFilters)) {
    if (!val) continue;
    const label = (CHIP_LABELS[key] && CHIP_LABELS[key][val]) || val;
    chips.push(`
      <span class="chip">
        ${label}
        <button class="chip__remove" onclick="removeFilter('${type}','${key}')" title="Remover filtro">✕</button>
      </span>
    `);
  }

  container.innerHTML = chips.join('');
}

function removeFilter(type, key) {
  const selectMap = {
    denuncias:    { status:'filterStatus', categoria:'filterCategoria', periodo:'filterPeriodo', bairro:'filterBairro' },
    funcionarios: { status:'filterStatusFunc', cargo:'filterCargo', ocorrencias:'filterOcorrencias' },
  };
  const selectId = selectMap[type][key];
  if (selectId) document.getElementById(selectId).value = '';
  if (type === 'denuncias')    filterDenuncias();
  if (type === 'funcionarios') filterFuncionarios();
}

/* ─────────────────────────────────────────
   CLEAR
───────────────────────────────────────── */
function clearSearch(type) {
  document.getElementById(`search${type.charAt(0).toUpperCase()+type.slice(1)}`).value = '';
  if (type === 'denuncias')    filterDenuncias();
  if (type === 'funcionarios') filterFuncionarios();
}

function clearAllFilters(type) {
  if (type === 'denuncias') {
    document.getElementById('searchDenuncias').value = '';
    ['filterStatus','filterCategoria','filterPeriodo','filterBairro','sortDenuncias'].forEach(id => {
      const el = document.getElementById(id);
      el.value = el.id === 'sortDenuncias' ? 'recente' : '';
      el.classList.remove('active-filter');
    });
    document.getElementById('clearDenuncias').classList.remove('visible');
    filterDenuncias();
  } else {
    document.getElementById('searchFuncionarios').value = '';
    ['filterCargo','filterStatusFunc','filterOcorrencias','sortFuncionarios'].forEach(id => {
      const el = document.getElementById(id);
      el.value = el.id === 'sortFuncionarios' ? 'nome' : '';
      el.classList.remove('active-filter');
    });
    document.getElementById('clearFuncionarios').classList.remove('visible');
    filterFuncionarios();
  }
}

/* ─────────────────────────────────────────
   INIT
───────────────────────────────────────── */
document.addEventListener('DOMContentLoaded', () => {
  filterDenuncias();
  filterFuncionarios();
});
