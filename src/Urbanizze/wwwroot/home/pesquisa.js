/* ═══════════════════════════════════════════════════════
   pesquisa.js — RF-12 e RF-13
   Dados vindos da API .NET → MSSQL
═══════════════════════════════════════════════════════ */

const API_BASE = 'http://localhost:5206/api'; // ← ajuste a porta para a da sua API .NET

let DENUNCIAS    = [];
let FUNCIONARIOS = [];

/* ─────────────────────────────────────────
   CARREGAR DADOS DA API
───────────────────────────────────────── */
async function carregarDenuncias() {
  try {
    const res  = await fetch(`${API_BASE}/denuncias`);
    DENUNCIAS  = await res.json();
  } catch (e) {
    console.error('Erro ao carregar denúncias:', e);
    DENUNCIAS = [];
  }
}

async function carregarFuncionarios() {
  try {
    const res    = await fetch(`${API_BASE}/funcionarios`);
    FUNCIONARIOS = await res.json();
  } catch (e) {
    console.error('Erro ao carregar funcionários:', e);
    FUNCIONARIOS = [];
  }
}

/* ─────────────────────────────────────────
   ESTADO DA APLICAÇÃO
───────────────────────────────────────── */
const state = {
  denuncias:    { page: 1, perPage: 8, filtered: [] },
  funcionarios: { page: 1, perPage: 8, filtered: [] },
};

/* ─────────────────────────────────────────
   HELPERS
───────────────────────────────────────── */
function daysAgo(n) {
  const d = new Date();
  d.setDate(d.getDate() - n);
  return d;
}

function highlight(text, query) {
  if (!query || !text) return text ?? '';
  const re = new RegExp(`(${query.replace(/[.*+?^${}()|[\]\\]/g, '\\$&')})`, 'gi');
  return String(text).replace(re, '<mark>$1</mark>');
}

function formatDate(str) {
  if (!str) return '';
  const [y, m, d] = str.split('-');
  return `${d}/${m}/${y}`;
}

function statusLabel(s) {
  const map = {
    ABERTA:     'Aberto',
    EM_ANALISE: 'Em análise',
    INDEFERIDA: 'Indeferida',
    CONCLUIDA:  'Concluída',
  };
  return map[s] || s;
}

function statusBadgeClass(s) {
  const map = {
    ABERTA:     'badge-open',
    EM_ANALISE: 'badge-progress',
    INDEFERIDA: 'badge-inativo',
    CONCLUIDA:  'badge-resolved',
  };
  return map[s] || '';
}

function occRangeMatch(n, range) {
  if (!range) return true;
  if (range === '0')    return n === 0;
  if (range === '1-5')  return n >= 1  && n <= 5;
  if (range === '6-10') return n >= 6  && n <= 10;
  if (range === '11+')  return n > 10;
  return true;
}

/* ─────────────────────────────────────────
   TABS
───────────────────────────────────────── */
function switchTab(tab) {
  document.querySelectorAll('.tab').forEach(t =>
    t.classList.toggle('tab--active', t.dataset.tab === tab));
  document.getElementById('panel-denuncias').classList.toggle('panel--hidden',    tab !== 'denuncias');
  document.getElementById('panel-funcionarios').classList.toggle('panel--hidden', tab !== 'funcionarios');
}

/* ─────────────────────────────────────────
   RF-12 — FILTRO DE DENÚNCIAS
───────────────────────────────────────── */
function filterDenuncias() {
  const q         = document.getElementById('searchDenuncias').value.trim().toLowerCase();
  const status    = document.getElementById('filterStatus').value;
  const categoria = document.getElementById('filterCategoria').value;
  const periodo   = document.getElementById('filterPeriodo').value;
  const bairro    = document.getElementById('filterBairro').value;
  const sort      = document.getElementById('sortDenuncias').value;

  document.getElementById('clearDenuncias').classList.toggle('visible', q.length > 0);

  ['filterStatus','filterCategoria','filterPeriodo','filterBairro'].forEach(id => {
    const el = document.getElementById(id);
    el.classList.toggle('active-filter', el.value !== '');
  });

  let result = DENUNCIAS.filter(d => {
    if (q && !(
      (d.titulo      || '').toLowerCase().includes(q) ||
      (d.localizacao || '').toLowerCase().includes(q) ||
      (d.departamento|| '').toLowerCase().includes(q)
    )) return false;

   if (status) {
  const statusMap = {
    'aberto':    'ABERTA',
    'andamento': 'EM_ANALISE',
    'resolvido': 'CONCLUIDA',
  };
  if (d.status?.toUpperCase() !== (statusMap[status] || status).toUpperCase()) return false;
}
   if (categoria) {
  const categoriaMap = {
    'infraestrutura': 'infraestrutura',
    'iluminacao':     'iluminação',
    'limpeza':        'lixo',
    'saneamento':     'saneamento',
    'acessibilidade': 'acessibilidade',
    'transporte':     'mobilidade',
  };
  const termoBusca = categoriaMap[categoria] || categoria;
  if (!(d.departamento || '').toLowerCase().includes(termoBusca)) return false;
}
    if (bairro    && !(d.localizacao || '').toLowerCase().includes(bairro.toLowerCase())) return false;

    if (periodo && d.criadoEm) {
      const date = new Date(d.criadoEm);
      if (periodo === 'hoje' && date < daysAgo(1))  return false;
      if (periodo === '7d'   && date < daysAgo(7))  return false;
      if (periodo === '30d'  && date < daysAgo(30)) return false;
      if (periodo === '90d'  && date < daysAgo(90)) return false;
    }

    return true;
  });

  if (sort === 'antigo') result.sort((a,b) => (a.criadoEm||'').localeCompare(b.criadoEm||''));
  else if (sort === 'titulo') result.sort((a,b) => (a.titulo||'').localeCompare(b.titulo||''));
  else result.sort((a,b) => (b.criadoEm||'').localeCompare(a.criadoEm||''));

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
      <td><span class="tag-protocol">#${d.id}</span></td>
      <td>${highlight(d.titulo, q)}</td>
      <td>${highlight(d.departamento, q)}</td>
      <td>${highlight(d.localizacao, q)}</td>
      <td>${formatDate(d.criadoEm)}</td>
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
  const q       = document.getElementById('searchFuncionarios').value.trim().toLowerCase();
  const cargo   = document.getElementById('filterCargo').value;
  const statusF = document.getElementById('filterStatusFunc').value;
  const ocorrFx = document.getElementById('filterOcorrencias').value;
  const sort    = document.getElementById('sortFuncionarios').value;

  document.getElementById('clearFuncionarios').classList.toggle('visible', q.length > 0);

  ['filterCargo','filterStatusFunc','filterOcorrencias'].forEach(id => {
    const el = document.getElementById(id);
    el.classList.toggle('active-filter', el.value !== '');
  });

  let result = FUNCIONARIOS.filter(f => {
    if (q && !(
      (f.nome  || '').toLowerCase().includes(q) ||
      (f.cargo || '').toLowerCase().includes(q)
    )) return false;
   if (cargo && !(f.cargo || '').toLowerCase().includes(cargo.toLowerCase())) return false;
    if (statusF && (f.status  || '').toLowerCase() !== statusF.toLowerCase()) return false;
    if (!occRangeMatch(f.ocorrencias || 0, ocorrFx)) return false;
    return true;
  });

  if (sort === 'ocorrencias') result.sort((a,b) => (b.ocorrencias||0) - (a.ocorrencias||0));
  else if (sort === 'cargo')  result.sort((a,b) => (a.cargo||'').localeCompare(b.cargo||''));
  else result.sort((a,b) => (a.nome||'').localeCompare(b.nome||''));

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

  const MAX_OCC = Math.max(...(FUNCIONARIOS.map(f => f.ocorrencias || 0)), 1);

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
      <td><span class="tag-protocol">F-${String(f.id).padStart(3,'0')}</span></td>
      <td>${highlight(f.nome, q)}</td>
      <td>${highlight(f.cargo, q)}</td>
      <td>
        <div class="occ-count">
          <span>${f.ocorrencias || 0}</span>
          <div class="occ-count-bar">
            <div class="occ-count-fill" style="width:${Math.round(((f.ocorrencias||0)/MAX_OCC)*100)}%"></div>
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
  const s     = state[type];
  const total = Math.ceil(s.filtered.length / s.perPage);
  const el    = document.getElementById(`pagination${type.charAt(0).toUpperCase()+type.slice(1)}`);

  if (total <= 1) { el.innerHTML = ''; return; }

  let html = `<button class="page-btn" ${s.page===1?'disabled':''} onclick="goPage('${type}',${s.page-1})">‹</button>`;
  for (let i = 1; i <= total; i++)
    html += `<button class="page-btn ${i===s.page?'page-btn--active':''}" onclick="goPage('${type}',${i})">${i}</button>`;
  html += `<button class="page-btn" ${s.page===total?'disabled':''} onclick="goPage('${type}',${s.page+1})">›</button>`;
  el.innerHTML = html;
}

function goPage(type, page) {
  state[type].page = page;
  const q = type === 'denuncias'
    ? document.getElementById('searchDenuncias').value.trim().toLowerCase()
    : document.getElementById('searchFuncionarios').value.trim().toLowerCase();
  if (type === 'denuncias')    renderDenuncias(q);
  if (type === 'funcionarios') renderFuncionarios(q);
  window.scrollTo({ top: 300, behavior: 'smooth' });
}

/* ─────────────────────────────────────────
   CHIPS DE FILTROS ATIVOS
───────────────────────────────────────── */
const CHIP_LABELS = {
  status:      { ABERTA:'Aberto', EM_ANALISE:'Em análise', INDEFERIDA:'Indeferida', CONCLUIDA:'Concluída', ativo:'Ativo', inativo:'Inativo' },
  categoria:   { infraestrutura:'Infraestrutura', iluminacao:'Iluminação', limpeza:'Limpeza', saneamento:'Saneamento', acessibilidade:'Acessibilidade', transporte:'Transporte' },
  periodo:     { hoje:'Hoje', '7d':'Últimos 7 dias', '30d':'Últimos 30 dias', '90d':'Últimos 90 dias' },
  bairro:      {'Centro':        'Centro','Savassi':       'Savassi','Vila Nova':     'Vila Nova','Jardim América':'Jardim América','Consolação':    'Consolação','Copacabana':    'Copacabana','Liberdade':     'Liberdade' },
  cargo:       {'Iluminação':  'Iluminação','Saneamento':  'Saneamento','Pavimentação':'Pavimentação','Lixo':        'Lixo','Mobilidade':  'Mobilidade' },
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
    ['filterStatus','filterCategoria','filterPeriodo','filterBairro'].forEach(id => {
      document.getElementById(id).value = '';
      document.getElementById(id).classList.remove('active-filter');
    });
    document.getElementById('sortDenuncias').value = 'recente';
    document.getElementById('clearDenuncias').classList.remove('visible');
    filterDenuncias();
  } else {
    document.getElementById('searchFuncionarios').value = '';
    ['filterCargo','filterStatusFunc','filterOcorrencias'].forEach(id => {
      document.getElementById(id).value = '';
      document.getElementById(id).classList.remove('active-filter');
    });
    document.getElementById('sortFuncionarios').value = 'nome';
    document.getElementById('clearFuncionarios').classList.remove('visible');
    filterFuncionarios();
  }
}

/* ─────────────────────────────────────────
   INIT — carrega do banco e renderiza
───────────────────────────────────────── */
document.addEventListener('DOMContentLoaded', async () => {
  await Promise.all([carregarDenuncias(), carregarFuncionarios()]);
  filterDenuncias();
  filterFuncionarios();
});